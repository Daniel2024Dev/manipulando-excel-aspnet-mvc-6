using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace ManutencaoVeicular.Controllers;// Controlador para operações relacionadas à entidade Anotacao

public class AnotacaoController : Controller
{
    public IActionResult Create()// Método para exibir a view de criação de uma nova Anotacao

    {
        return View();// Retorna a view correspondente
    }
    [HttpPost]// Atributo que indica que este método responde a solicitações HTTP POST
    public IActionResult Create(PropertyAnotacaoModel property)// Método para lidar com a submissão do formulário de criação de Anotacao
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório para manipular operações de banco de dados

        repository.Inserir(property);// Chama o método Inserir do repositório para adicionar a Anotacao ao banco de dados
        return RedirectToAction("Read");// Redireciona para a action Read para exibir a lista atualizada de Anotacoes
    }

    public IActionResult Read()// Método para exibir a lista de Anotacoes
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório para manipular operações de banco de dados
        return View(repository.Listar());// Retorna a view de leitura com a lista de Anotacoes obtida do banco de dados
    }

    public IActionResult Update(int Id)// Método para exibir a view de atualização de uma Anotacao específica
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório para manipular operações de banco de dados
        return View(repository.BuscaPorId(Id));// Retorna a view de atualização com os dados da Anotacao obtidos do banco de dados
    }
    [HttpPost][HttpPost] // Atributo que indica que este método responde a solicitações HTTP POST
    public IActionResult Update(PropertyAnotacaoModel property)// Método para lidar com a submissão do formulário de atualização de Anotacao
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório para manipular operações de banco de dados
        repository.Editar(property);// Chama o método Editar do repositório para atualizar os dados da Anotacao no banco de dados
        return RedirectToAction("Read");// Redireciona para a action Read para exibir a lista atualizada de Anotacoes
    }
    public IActionResult Delete(int Id)// Método para excluir uma Anotacao
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();// Cria uma instância do repositório para manipular operações de banco de dados
        repository.Deletar(Id);// Chama o método Deletar do repositório para excluir a Anotacao do banco de dados
        return RedirectToAction("Read");// Redireciona para a action Read para exibir a lista atualizada de Anotacoes
    }
}