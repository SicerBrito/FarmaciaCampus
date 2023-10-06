# Documentación 📄
En esta carpeta se crearan cada uno de los repositorios en los cuales va a ir la configuración especifica para cada uno de los metodos de nuestras consultas o endpoints a realizar.

Estos metodos deberen ir referenciados desde las interfaces para poder poceder a los repositorios y terminar con los controladores utilizando LINQ con  
![C#](Img/image.png)

## LINQ con C#

Primero que nada que es LINQ?  
 - ### LINQ   
    Significa Language Integrated Query (Consulta Integrada en el Lenguaje), es una característica de programación que se encuentra en varios lenguajes de programación, especialmente en el entorno de desarrollo de Microsoft, como C# y Visual Basic .NET. LINQ permite realizar consultas y operaciones sobre conjuntos de datos de una manera más intuitiva y orientada a objetos, utilizando una sintaxis similar a SQL (Structured Query Language).   
   
    LINQ simplifica la manipulación y consulta de datos, lo que a su vez mejora la productividad y la calidad del código.

 - ### LINQ con C#   
    La diferencia radica entre LINQ en C# y LINQ en otros lenguajes radica en que C# proporciona características específicas de sintaxis y herramientas de desarrollo que facilitan el uso de LINQ de manera más natural en el código C#.  

---

### GetAllMedicamentos():

 - La consulta GetAllMedicamentos retorna una consulta IQueryable<Medicamento> que aún no se ha ejecutado. Puedes usar esta consulta más adelante para realizar operaciones adicionales como proyecciones, ordenamientos o agrupamientos antes de ejecutarla para obtener los resultados finales.

   
   public IQueryable<Medicamento> GetAllMedicamentos(): Este es el encabezado de un método público llamado GetAllMedicamentos. El método devuelve un objeto IQueryable<Medicamento>, lo que significa que este método retornará una consulta que se puede ejecutar más adelante.

   {}: Estas llaves delimitan el cuerpo del método, donde se encuentra la lógica de la consulta.

   return _Context.Set<Medicamento>().Where(m => m.Stock < 50);: Esto es lo que hace la consulta:

   _Context: Supongo que _Context es un objeto que representa el contexto de la base de datos o la fuente de datos en la que se almacenan los medicamentos. En general, es una instancia de una clase que proporciona acceso a la base de datos a través de Entity Framework u otro ORM similar.

   .Set<Medicamento>(): Esto indica que se va a trabajar con la tabla o entidad Medicamento en la base de datos.

   .Where(m => m.Stock < 50): Aquí se está aplicando un filtro a la consulta. Se seleccionarán todos los registros de la tabla Medicamento donde el valor de la propiedad Stock sea menor que 50.

   Obtiene una consulta de todos los medicamentos en la base de datos donde el stock es menor que 50.

   Ejemplo de uso de esta consulta:

   var medicamentosQuery = GetAllMedicamentos();
   var medicamentosFiltrados = medicamentosQuery.Where(m => m.Nombre.Contains("Aspirina")).OrderBy(m => m.Precio).ToList();

---

### ObtenerMedicamentosCompradosPorProveedorId(int proveedorId):

 - Obtiene una lista de medicamentos que han sido comprados por un proveedor específico identificado por proveedorId.

   ObtenerMedicamentosCompradosPorProveedorId(int proveedorId): Este método recibe un parámetro proveedorId y devuelve una tarea (Task) que representa una colección de medicamentos (IEnumerable<Medicamento?>).

   El método utiliza _Context, que parece ser el contexto de la base de datos, para acceder a la entidad MedicamentosComprados.

   .Where(c => c.Medicamentos!.ProveedorId == proveedorId): Esto filtra los registros de MedicamentosComprados para obtener solo aquellos donde el ProveedorId del medicamento coincide con el valor proporcionado en proveedorId.

   .Select(c => c.Medicamentos): Luego, selecciona solo la propiedad Medicamentos de cada registro, que parece ser una relación entre MedicamentosComprados y Medicamento.

   .ToListAsync(): Finalmente, ejecuta la consulta y obtiene los resultados como una lista de medicamentos, que se devuelve como resultado.

---

### ObtenerMedicamentosCaducanAntesDe2024():

 - Obtiene una lista de medicamentos que caducarán antes del año 2024.

   ObtenerMedicamentosCaducanAntesDe2024(): Este método no recibe parámetros y devuelve una tarea que representa una lista de medicamentos (List<Medicamento>).

   El método crea una variable fechaLimite que representa el 1 de enero de 2024.

   Luego, se realiza una consulta en la entidad Medicamentos para obtener todos los medicamentos cuya fecha de expiración sea anterior a fechaLimite.

   .ToListAsync(): Finalmente, la consulta se ejecuta y se obtienen los resultados como una lista de medicamentos, que se devuelve como resultado.
 
---

### ObtenerTotalMedicamentosVendidosPorProveedor():

 - Obtiene información sobre la cantidad total de medicamentos vendidos por cada proveedor. Devuelve una lista de objetos anónimos con detalles del proveedor y la cantidad total vendida.

   ObtenerTotalMedicamentosVendidosPorProveedor(): Este método no recibe parámetros y devuelve una tarea que representa una colección de objetos anónimos (IEnumerable<object>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .GroupBy(medicamento => medicamento.Proveedores!.Nombres): Aquí se agrupan los medicamentos por el nombre del proveedor (Nombres) al que están asociados.

   .Select(group => new {...}): Luego, se realiza una proyección en la que se crea un nuevo objeto anónimo por cada grupo. Este objeto contiene información sobre el proveedor y la cantidad total de medicamentos vendidos por ese proveedor.

   TotalVendidos = group.Sum(...): Para calcular la cantidad total vendida, se realiza una suma de las cantidades vendidas de los medicamentos en ese grupo.

   .ToListAsync(): Finalmente, se ejecuta la consulta y se obtienen los resultados como una lista de objetos anónimos.

---

### ObtenerMedicamentosNoVendidos():

 - Obtiene una lista de medicamentos que no han sido vendidos, es decir, aquellos que tienen un recuento de ventas igual a cero.

   ObtenerMedicamentosNoVendidos(): Este método no recibe parámetros y devuelve una tarea que representa una colección de medicamentos que no han sido vendidos (IEnumerable<Medicamento>).

   La consulta utiliza _Context.Medicamentos para acceder a la entidad Medicamentos.

   .Where(medicamento => medicamento.MedicamentosVendidos!.Count == 0): Filtra los medicamentos que no tienen ninguna venta asociada, es decir, aquellos cuyo recuento de ventas es igual a cero.

   .ToListAsync(): Finalmente, la consulta se ejecuta y se obtienen los resultados como una lista de medicamentos.

---

### ObtenerMedicamentoMasCaro():

 - Obtiene el medicamento más caro basado en su valor unitario.

   ObtenerMedicamentoMasCaro(): Este método no recibe parámetros y devuelve una tarea que representa el medicamento más caro (Task<Medicamento>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .OrderByDescending(medicamento => medicamento.ValorUnidad): Los medicamentos se ordenan en orden descendente según su valor unitario (ValorUnidad), lo que significa que el medicamento más caro estará en la parte superior de la lista.

   .FirstOrDefaultAsync(): Se toma el primer medicamento de la lista ordenada, que será el medicamento más caro.

---

### ObtenerNumeroMedicamentosPorProveedor():

 - Obtiene un diccionario que muestra cuántos medicamentos ofrece cada proveedor.

   ObtenerNumeroMedicamentosPorProveedor(): Este método no recibe parámetros y devuelve una tarea que representa un diccionario que contiene el número de medicamentos por proveedor (Task<Dictionary<string, int>>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .GroupBy(medicamento => medicamento.Proveedores!.Nombres!): Los medicamentos se agrupan por el nombre del proveedor (Nombres) al que están asociados. El signo de exclamación ! indica que se está suprimiendo una posible excepción de referencia nula.

   .ToDictionaryAsync(group => group.Key, group => group.Count()): Se convierte el resultado de la agrupación en un diccionario donde la clave es el nombre del proveedor y el valor es la cantidad de medicamentos asociados a ese proveedor.

---

### ObtenerMedicamentosQueExpiranEn2024():

 - Obtiene una lista de medicamentos que caducarán en el año 2024.

   ObtenerMedicamentosQueExpiranEn2024(): Este método no recibe parámetros y devuelve una tarea que representa una lista de medicamentos que caducarán en el año 2024 (Task<List<Medicamento>>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .Where(m => m.FechaExpiracion.Year == 2024): Filtra los medicamentos cuya fecha de expiración pertenece al año 2024.

   .ToListAsync(): Finalmente, la consulta se ejecuta y se obtienen los resultados como una lista de medicamentos.

---

### ObtenerMedicamentosNuncaVendidos():

 - Obtiene una lista de medicamentos que nunca han sido vendidos, es decir, aquellos con un recuento de ventas igual a cero.

   ObtenerMedicamentosNuncaVendidos(): Este método no recibe parámetros y devuelve una tarea que representa una lista de medicamentos que nunca han sido vendidos (Task<List<Medicamento>>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .Where(m => m.MedicamentosVendidos!.Count == 0): Filtra los medicamentos que no tienen ventas asociadas, es decir, aquellos cuyo recuento de ventas es igual a cero.

   .ToListAsync(): Finalmente, la consulta se ejecuta y se obtienen los resultados como una lista de medicamentos.

---

### ObtenerMedicamentosVendidosPorMesEn2023():

 - Obtiene un diccionario que muestra los medicamentos vendidos para cada mes en el año 2023.

   ObtenerMedicamentosVendidosPorMesEn2023(): Este método no recibe parámetros y devuelve una tarea que representa un diccionario que contiene medicamentos vendidos por mes en el año 2023 (Task<Dictionary<string, List<Medicamento>>>).

   El método crea un diccionario llamado medicamentosPorMes para almacenar medicamentos vendidos por mes.

   Luego, itera a través de los meses del año (de 1 a 12) y, para cada mes, realiza una consulta para obtener los medicamentos vendidos en ese mes en particular.

   .Where(...): Filtra los medicamentos vendidos en el mes específico de 2023.

   .ToListAsync(): Ejecuta la consulta y obtiene los resultados como una lista de medicamentos para cada mes.

   El diccionario medicamentosPorMes se actualiza con los resultados, donde cada clave es el nombre del mes y el valor es la lista de medicamentos vendidos en ese mes.

---

### ObtenerMedicamentosNoVendidosEn2023():

 - Obtiene una lista de medicamentos que no han sido vendidos en el año 2023.

   ObtenerMedicamentosNoVendidosEn2023(): Este método no recibe parámetros y devuelve una tarea que representa una lista de medicamentos que no han sido vendidos en el año 2023 (Task<List<Medicamento>>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .Where(...): Filtra los medicamentos que no tienen ventas asociadas en el año 2023, es decir, aquellos cuyo recuento de ventas es igual a cero en ese año.

   .ToListAsync(): La consulta se ejecuta y se obtienen los resultados como una lista de medicamentos.

---

### ObtenerMedicamentosPrecioStock():

 - Obtiene una lista de medicamentos con un valor unitario superior a 50 y un stock inferior a 100. Esta consulta también filtra medicamentos que tienen un valor unitario válido (que puede ser convertido a un número).

   ObtenerMedicamentosPrecioStock(): Este método no recibe parámetros y devuelve una tarea que representa una lista de medicamentos que cumplen con ciertos criterios de precio y stock (Task<List<Medicamento>>).

   La consulta comienza con _Context.Medicamentos, lo que implica que se trabaja con la entidad Medicamentos.

   .Where(...): Se filtran los medicamentos que tienen un valor unitario (ValorUnidad) válido, es decir, no nulo.

   Luego, la lista resultante de medicamentos se filtra nuevamente para seleccion

---