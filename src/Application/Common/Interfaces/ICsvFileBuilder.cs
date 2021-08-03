using Movies.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Movies.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
