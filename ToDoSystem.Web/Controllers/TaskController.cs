using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ToDoSystem.Dtos.Task;
using ToDoSystem.Web.Models.Task;


namespace ToDoSystem.Web.Controllers;
public class TaskController: Controller
{
    readonly Uri baseAddress = new("http://localhost:5244/api");
    readonly HttpClient _client;
    public TaskController()
    {
        _client = new HttpClient
        {
            BaseAddress = baseAddress
        };
    }

    [HttpGet("/index")]
    public async Task<IActionResult> Index()
    {
        List<TaskViewModel> tasks = [];
        HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/tasks/GetTasks");

        if(response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync( );
            tasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(data)!;
        }

        var timeZone = TimeZoneInfo.Local;
        foreach(var task in tasks)
        {
            task.CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(task.CreatedAt,timeZone);
            if(task.CompletedAt.HasValue)
            {
                task.CompletedAt = TimeZoneInfo.ConvertTimeFromUtc(task.CompletedAt.Value,timeZone);
            }
        }

        return View(tasks);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View( );
    }
    [HttpPost]
    public async Task<IActionResult> Create(TaskCreationDto taskCreation)
    {
        try
        {
            string data = JsonConvert.SerializeObject(taskCreation);
            StringContent content = new(data,Encoding.UTF8,"application/json");

            HttpResponseMessage responseMessage = await _client.PostAsync(_client.BaseAddress + "/tasks/PostTask",content);

            if(responseMessage.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Tarefa Criada com sucesso";
                return RedirectToAction("Index");
            }
            
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View( );
        }
        return View( );
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        try
        {
            TaskPutDto taskPutDto = new( );
            HttpResponseMessage responseMessage = await _client.GetAsync(_client.BaseAddress + $"/tasks/GetTaskId/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync( );
                taskPutDto = JsonConvert.DeserializeObject<TaskPutDto>(data)!;
            }
            return View(taskPutDto);
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View( );
        }
    }

    [HttpPost("/{id}")]
    public async Task<IActionResult> Edit(TaskPutDto taskPutDto, Guid id)
    {
        try
        {
            string data = JsonConvert.SerializeObject(taskPutDto);
            StringContent content = new(data,Encoding.UTF8,"application/json");

            HttpResponseMessage responseMessage = await _client.PutAsync(_client.BaseAddress + $"/tasks/PutTask/editar/" + id , content);

            if(responseMessage.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Tarefa Editada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Erro ao editar a tarefa:";
                return View(taskPutDto);
            }
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View( );
        }
    }
    [HttpGet("/detalhes/{id}")]
    public async Task<IActionResult> Details(Guid id) 
    {
        try
        {
            TaskResponseDto taskResponse = new( );
            HttpResponseMessage responseMessage = await _client.GetAsync(_client.BaseAddress + $"/tasks/GetTaskId/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync( );
                taskResponse = JsonConvert.DeserializeObject<TaskResponseDto>(data)!;
            }
            return View(taskResponse);
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View( );
        }

    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            TaskResponseDto taskResponse = new( );
            HttpResponseMessage responseMessage = await _client.GetAsync(_client.BaseAddress + $"/tasks/GetTaskId/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                string data = await responseMessage.Content.ReadAsStringAsync( );
                taskResponse = JsonConvert.DeserializeObject<TaskResponseDto>(data)!;
            }
            return View(taskResponse);
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        try
        {
            HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + $"/tasks/DeleteTask/{id}");

            if(response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Tarefa Deletada com sucesso";
                return RedirectToAction("Index");
            }
        }
        catch(Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View( );
        }
        return View();
    }
}
