using AutoMapper;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

public class BaseController : ControllerBase
{
    protected readonly IRepositoryManager _repository;

    public BaseController(IRepositoryManager repository)
    {
        _repository = repository;
    }
}