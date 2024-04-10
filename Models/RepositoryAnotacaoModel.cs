using ClosedXML.Excel; // Importa o namespace para trabalhar com Excel

namespace AgendaVeicular.Models;
public class RepositoryAnotacaoModel
{

    // Método para criar a pasta e o arquivo DataBase.xlsx se não existirem
    public void CriaDiretorio()
    {
        // Define o caminho do arquivo de banco de dados
        string Diretorio = "DataBase/DataBase.xlsx";
        // Cria um objeto FileInfo para verificar se o arquivo já existe
        FileInfo file = new FileInfo(Diretorio);

        // Verifica se o arquivo não existe
        if (! file.Exists)
        {
            // Cria um novo arquivo Excel utilizando a biblioteca ClosedXML
            var workbook = new XLWorkbook();

            // Adiciona uma planilha chamada "DB2" ao novo arquivo
            workbook.Worksheets.Add("DB2");

            // Salva o arquivo Excel no caminho especificado
            workbook.SaveAs("DataBase/DataBase.xlsx");
        }
    }

    // Método para inserir uma nova Anotação no arquivo Excel
    public void Inserir(PropertyAnotacaoModel property)
    {
        // Carrega o arquivo Excel existente
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");

        // Seleciona a planilha "DB2" no arquivo Excel
        var worksheet = workbook.Worksheet("DB2");
        
        // Calcula o número da próxima linha disponível na planilha
        int Aux = worksheet.Rows().Count() + 1;

        // Define o valor do ID da Anotação na coluna A da próxima linha disponível
        worksheet.Cell("A" + Aux).Value =  Aux;

        // Define o valor da DataAtual da Anotação na coluna B da próxima linha disponível
        worksheet.Cell("B" + Aux).Value = property.DataAtual;

        // Define o valor dos Registros da Anotação na coluna C da próxima linha disponível
        worksheet.Cell("C" + Aux).Value = property.Registros;

        // Salva as alterações no arquivo Excel
        workbook.SaveAs("DataBase/DataBase.xlsx");

    }
    
    // Método para listar todas as Anotações do arquivo Excel
    public List<PropertyAnotacaoModel> Listar()
    {
        
        List<PropertyAnotacaoModel> Lista = new List<PropertyAnotacaoModel>();// Cria uma lista para armazenar as Anotações
        
        int i = 0;// Inicializa o contador para iterar sobre as linhas da planilha
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");// Carrega o arquivo Excel
        var worksheet = workbook.Worksheet("DB2");// Seleciona a planilha "DB2" no arquivo Excel

        // Itera sobre as linhas da planilha até que não haja mais linhas
        while(worksheet.Rows().Count() > i)
        {
            i++;// Incrementa o contador

            // Cria um novo objeto PropertyAnotacaoModel para armazenar os dados da Anotação
            PropertyAnotacaoModel property = new PropertyAnotacaoModel();

            // Obtém o valor da coluna A (IdAnotacao) da linha atual e atribui ao objeto property
            property.IdAnotacao = worksheet.Cell("A" + i).GetValue<int>();

            // Obtém o valor da coluna B (DataAtual) da linha atual e atribui ao objeto property
            property.DataAtual = worksheet.Cell("B" + i).GetValue<DateTime>();

            // Obtém o valor da coluna C (Registros) da linha atual e atribui ao objeto property
            property.Registros = worksheet.Cell("C" + i).GetValue<string>();
            
            // Adiciona o objeto property à lista Lista
            Lista.Add(property);
        }
        // Verifica se não há nenhuma linha na planilha (ou seja, se não há Anotações)
        if(worksheet.Rows().Count() == 0)
        {
            // Cria um objeto PropertyAnotacaoModel com Registros "empty" para indicar que não há Anotações
            PropertyAnotacaoModel property = new PropertyAnotacaoModel();
            property.Registros = "empty";

            // Adiciona o objeto property à lista Lista
            Lista.Add(property);
        }
        
        Lista.Reverse();// Reverte a lista para que as Anotações mais recentes fiquem no topo
        // Retorna a lista de Anotações
        return Lista;
    }

   // Método para editar uma Anotação existente no arquivo Excel
    public void Editar(PropertyAnotacaoModel property)
    {
        
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");// Carrega o arquivo Excel existente
        var worksheet = workbook.Worksheet("DB2");// Seleciona a planilha "DB2" no arquivo Excel
        // Define o valor da DataAtual da Anotação na coluna B, linha correspondente ao IdAnotacao da Anotação que está sendo editada
        worksheet.Cell("B" + property.IdAnotacao).Value = property.DataAtual;
        // Define o valor dos Registros da Anotação na coluna C, linha correspondente ao IdAnotacao da Anotação que está sendo editada
        worksheet.Cell("C" + property.IdAnotacao).Value = property.Registros;
        // Salva as alterações no arquivo Excel
        workbook.SaveAs("DataBase/DataBase.xlsx");
    }

    // Método para buscar uma Anotação pelo seu Id no arquivo Excel
    public PropertyAnotacaoModel BuscaPorId(int Id)
    {
        
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");// Carrega o arquivo Excel
        var worksheet = workbook.Worksheet("DB2");// Seleciona a planilha "DB2" no arquivo Excel

        PropertyAnotacaoModel property = new PropertyAnotacaoModel();// Cria um novo objeto PropertyAnotacaoModel para armazenar os dados da Anotação

        // Obtém o valor do IdAnotacao da Anotação na linha correspondente ao Id fornecido
        property.IdAnotacao = worksheet.Cell("A" + Id).GetValue<int>();

        // Obtém o valor da DataAtual da Anotação na linha correspondente ao Id fornecido
        property.DataAtual = worksheet.Cell("B" + Id).GetValue<DateTime>();

        // Obtém o valor dos Registros da Anotação na linha correspondente ao Id fornecido
        property.Registros = worksheet.Cell("C" + Id).GetValue<string>();

        // Retorna o objeto PropertyAnotacaoModel com os dados da Anotação encontrada
        return property;
    }
    
    // Método para excluir uma Anotação do arquivo Excel
    public void Deletar(int Id)
    {   
        DateTime Data = DateTime.Now;// Obtém a data e hora atuais  
        
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");
        
        worksheet.Cell("B" + Id).Value = Data;// Define a data e hora da exclusão na coluna B da linha correspondente à Anotação que está sendo excluída
        
        worksheet.Cell("C" + Id).Value = "null";// Define "null" na coluna C da linha correspondente à Anotação que está sendo excluída para indicar que não há mais registros associados a essa Anotação

        workbook.SaveAs("DataBase/DataBase.xlsx");// Salva as alterações no arquivo Excel
    }
}