namespace TodoApi.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; } //Este T mostra pro compilador que a propriedade pode ser um tipo genérico. Estou fazendo isso pq a prop Data pode ser tanto do tipo Author quanto do tipo Book. 
         public string _message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
