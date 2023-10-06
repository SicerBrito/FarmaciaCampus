# Documentación

Estos tipos y patrones son comunes en C# para trabajar con operaciones asincrónicas, colecciones de datos, consultas y valores numéricos, y se utilizan en diferentes contextos según los requisitos específicos de la aplicación.

1. IQueryable:

    IQueryable es una interfaz que representa una consulta a una fuente de datos. Permite construir consultas en lenguaje LINQ que se ejecutan en una fuente de datos (como una base de datos) cuando se necesita, permitiendo la consulta diferida.

     - IQueryable:

        ¿Qué hace? Representa una consulta a una fuente de datos que aún no se ha ejecutado.  
        ¿Para qué funciona? Permite construir consultas LINQ flexibles que se ejecutan de manera eficiente en la fuente de datos subyacente (como una base de datos) cuando se necesita.  
        Ejemplo de uso:  

            IQueryable<Medicamento> query = dbContext.Medicamentos;
            var medicamentosCaducados = query.Where(m => m.FechaCaducidad < DateTime.Now);

    ---

2. Task:

    Task es una clase en C# que se usa para representar una operación asincrónica. Permite realizar operaciones en segundo plano sin bloquear el hilo principal de ejecución.

     - Task:

        ¿Qué hace? Representa una operación asincrónica.  
        ¿Para qué funciona? Permite realizar operaciones en segundo plano sin bloquear el hilo principal de ejecución, lo que es útil para realizar tareas que pueden llevar tiempo, como llamadas a API, acceso a bases de datos, etc.  
        Ejemplo de uso:  

            public async Task<string> ObtenerDatosAsync()
            {
                // Realizar operación asincrónica
                await Task.Delay(1000);
                return "Datos obtenidos";
            }

    ---
3. IEnumerable:

    IEnumerable es una interfaz que representa una secuencia de elementos. Permite iterar a través de una colección de datos en un enfoque de lectura.

     - IEnumerable:

        ¿Qué hace? Representa una secuencia de elementos que se pueden recorrer.  
        ¿Para qué funciona? Permite iterar a través de una colección de datos de manera eficiente y realizar operaciones de lectura en ella.
        Ejemplo de uso:  

            IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var numero in numeros)
            {
                Console.WriteLine(numero);
            }
    ---
 - Task<IEnumerable<object>>:

    Esto representa una tarea que devuelve una secuencia de objetos. Es útil cuando se espera una colección de objetos como resultado de una operación asincrónica.
    
    ---

 - Task<IEnumerable<Medicamento>>:

    Similar al anterior, representa una tarea que devuelve una secuencia de objetos de tipo Medicamento. Útil cuando se espera una colección de medicamentos como resultado de una operación asincrónica.

    ---

4. Dictionary:

    Dictionary es una clase en C# que representa una colección de pares clave-valor. Permite asociar un valor (valor) con una clave única (llave).

     - Dictionary:

        ¿Qué hace? Almacena pares clave-valor.  
        ¿Para qué funciona? Permite asociar un valor con una clave única y recuperar ese valor rápidamente a través de la clave.  
        Ejemplo de uso:  

        Dictionary<string, int> diccionario = new Dictionary<string, int>();
        diccionario["Uno"] = 1;
        int valor = diccionario["Uno"]; // valor contiene 1
    ---

 - Task<List<Medicamento>>:

    Representa una tarea que devuelve una lista de objetos Medicamento. Útil cuando se espera una lista de medicamentos como resultado de una operación asincrónica.

    ---

 - Task<Dictionary<string, List<Medicamento>>>:

    Esto representa una tarea que devuelve un diccionario donde las claves son cadenas y los valores son listas de objetos Medicamento. Útil para obtener datos organizados de esta manera como resultado de una operación asincrónica.

    ---

 - Task<decimal> y Task<double>:

    Representan tareas que devuelven valores decimales y valores de punto flotante de doble precisión, respectivamente. Útil cuando se espera un valor numérico como resultado de una operación asincrónica.

    ---

 - Task<int>:

    Representa una tarea que devuelve un valor entero. Útil cuando se espera un valor entero como resultado de una operación asincrónica.

    ---

 - Task<Medicamento>:

    Representa una tarea que devuelve un objeto Medicamento. Útil cuando se espera un solo medicamento como resultado de una operación asincrónica.

    ---

 - Task<Dictionary<string, int>>:

    Esto representa una tarea que devuelve un diccionario donde las claves son cadenas y los valores son valores enteros. Útil para obtener datos organizados de esta manera como resultado de una operación asincrónica.

    ---

 - Task<List<Empleado>>:

    Representa una tarea que devuelve una lista de objetos Empleado. Útil cuando se espera una lista de empleados como resultado de una operación asincrónica.

    ---

 - Task<Dictionary<string, decimal>>:

    Esto representa una tarea que devuelve un diccionario donde las claves son cadenas y los valores son valores decimales. Útil para obtener datos organizados de esta manera como resultado de una operación asincrónica.

    ---

 - Task<decimal>:

    Representa una tarea que devuelve un valor decimal. Útil cuando se espera un valor decimal como resultado de una operación asincrónica.

5. decimal, double, int:

    ¿Qué hacen? Representan valores numéricos de diferentes tipos.  
    ¿Para qué funcionan? Permiten almacenar y realizar operaciones matemáticas con valores numéricos.  
    Ejemplo de uso:  

        decimal precio = 19.99m;
        int cantidad = 5;
        decimal total = precio * cantidad; // total contiene 99.95