# manipulando-excel-aspnet-mvc-6

O código fornecido implementa um sistema de gerenciamento de anotações em um arquivo do Excel usando a linguagem de programação C#. Aqui está um resumo das principais funcionalidades e estrutura do código:

Namespace e Referências: O código está dentro do namespace AgendaVeicular.Models e faz uso da biblioteca ClosedXML.Excel para manipular arquivos do Excel.

Classe RepositoryAnotacaoModel: Esta classe encapsula as operações de manipulação de anotações no arquivo do Excel.

Método CriaDiretorio(): Verifica se o arquivo DataBase.xlsx existe. Se não existir, cria um novo arquivo Excel com uma planilha chamada DB2.

Método Inserir(PropertyAnotacaoModel property): Insere uma nova anotação no arquivo Excel, determinando a próxima linha disponível e inserindo os dados da nova anotação nas colunas correspondentes.

Método Listar(): Lista todas as anotações presentes no arquivo Excel, armazenando os dados de cada anotação em uma lista de objetos PropertyAnotacaoModel. Se não houver anotações, adiciona um objeto com Registros "empty" à lista.

Método Editar(PropertyAnotacaoModel property): Edita uma anotação existente no arquivo Excel com base no IdAnotacao fornecido.

Método BuscaPorId(int Id): Busca uma anotação pelo seu IdAnotacao no arquivo Excel e retorna um objeto PropertyAnotacaoModel com esses dados.

Método Deletar(int Id): Exclui uma anotação do arquivo Excel, definindo a data e hora da exclusão e marcando os registros como "null".
