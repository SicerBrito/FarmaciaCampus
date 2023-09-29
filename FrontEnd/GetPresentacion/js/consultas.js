const apiButtonsDiv = document.getElementById('api-buttons');

// Lista de URLs y sus nombres
const apiEndpoints = [
    { url: 'http://localhost:5000/api/sicer/Medicamento/stockbajo/', name: '1-stockbajo' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/proveedoresConMedicamentos/', name: '2-proveedoresConMedicamentos' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/proveedor/2/', name: '3-proveedor' },
    { url: 'http://localhost:5000/api/sicer/FormulaMedica/recetasDespuesDe2023/', name: '4-recetasDespuesDe2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/totalVentasParacetamol/', name: '5-totalVentasParacetamol' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosCaducanAntesDe2024/', name: '6-medicamentosCaducanAntesDe2024' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosVendidosPorCadaProveedor/', name: '7-medicamentosVendidosPorCadaProveedor' },
    { url: 'http://localhost:5000/api/sicer/Venta/totalDineroRecaudadoPorVentas/', name: '8-totalDineroRecaudadoPorVentas' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosNoVendidos/', name: '9-medicamentosNoVendidos' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentoMasCaro/', name: '10-medicamentoMasCaro' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosPorProveedor/', name: '11-medicamentosPorProveedor' },
    { url: 'http://localhost:5000/api/sicer/Paciente/pacientesQueCompraronParacetamol/', name: '12-pacientesQueCompraronParacetamol' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/proveedoresSinVentasUltimoAnio/', name: '13-proveedoresSinVentasUltimoAnio' },
    { url: 'http://localhost:5000/api/sicer/Venta/totalMedicamentosVendidosEnMarzo2023/', name: '14-totalMedicamentosVendidosEnMarzo2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/medicamentoMenosVendidoEn2023/', name: '15-medicamentoMenosVendidoEn2023' },
    { url: 'http://localhost:5000/api/sicer/Compra/gananciaTotalPorProveedorEn2023/1/', name: '16-gananciaTotalPorProveedorEn2023   ' },
    { url: 'http://localhost:5000/api/sicer/Venta/promedioMedicamentosCompradosPorVenta/', name: '17-promedioMedicamentosCompradosPorVenta' },
    { url: 'http://localhost:5000/api/sicer/Venta/cantidadVentasPorEmpleadoEn2023/', name: '18-cantidadVentasPorEmpleadoEn2023' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosExpiranEn2024/', name: '19-medicamentosExpiranEn2024' },
    { url: 'http://localhost:5000/api/sicer/Empleado/empleadosConMasDe5Ventas/', name: '20-empleadosConMasDe5Ventas' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosNuncaVendidos/', name: '21-medicamentosNuncaVendidos' },
    { url: 'http://localhost:5000/api/sicer/Paciente/pacienteMayorGasto2023/', name: '22-pacienteMayorGasto2023' },
    { url: 'http://localhost:5000/api/sicer/Empleado/empleadosSinVentasEn2023/', name: '23-empleadosSinVentasEn2023' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/proveedorConMasSuministrosEn2023/', name: '24-proveedorConMasSuministrosEn2023' },
    { url: 'http://localhost:5000/api/sicer/Paciente/pacientesQueCompraronParacetamolEn2023/', name: '25-pacientesQueCompraronParacetamolEn2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/totalMedicamentosVendidosPorMesEn2023/', name: '26-totalMedicamentosVendidosPorMesEn2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/empleadosConMenosDe5VentasEn2023/', name: '27-empleadosConMenosDe5VentasEn2023' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/numeroProveedoresSuministraronEn2023/', name: '28-numeroProveedoresSuministraronEn2023' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/proveedoresDeMedicamentosConStockBajo/', name: '29-proveedoresDeMedicamentosConStockBajo' },
    { url: 'http://localhost:5000/api/sicer/Paciente/pacientesSinComprasEn2023/', name: '30-pacientesSinComprasEn2023' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosVendidosPorMesEn2023/', name: '31-medicamentosVendidosPorMesEn2023' },
    { url: 'http://localhost:5000/api/sicer/Empleado/empleadoMayorCantidadMedicamentosVendidosEn2023/', name: '32-empleadoMayorCantidadMedicamentosVendidosEn2023' },
    { url: 'http://localhost:5000/api/sicer/Paciente/totalGastadoPorPacienteEn2023/', name: '33-totalGastadoPorPacienteEn2023' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/medicamentosNoVendidosEn2023/', name: '34-medicamentosNoVendidosEn2023' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/proveedoresCon5MedicamentosEn2023/', name: '35-proveedoresCon5MedicamentosEn2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/totalMedicamentosVendidosPrimerTrimestre2023/', name: '36-totalMedicamentosVendidosPrimerTrimestre2023' },
    { url: 'http://localhost:5000/api/sicer/Venta/empleadosSinVentasAbril2023/', name: '37-empleadosSinVentasAbril2023' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/MedicamentosPrecioStock/', name: '38-MedicamentosPrecioStock' },
    // Agrega más URLs y nombres aquí...
];

// Crea botones y elementos para mostrar JSON
apiEndpoints.forEach(endpoint => {
    const buttonContainer = document.createElement('div');
    buttonContainer.className = 'api-button-container';

    const button = document.createElement('button');
    button.className = 'api-button';
    button.textContent = `Mostrar ${endpoint.name}`;

    const jsonData = document.createElement('div');
    jsonData.className = 'json-data';
    jsonData.setAttribute('data-endpoint', endpoint.name);

    button.addEventListener('click', () => toggleDatos(endpoint.url, jsonData, button));

    buttonContainer.appendChild(button);
    buttonContainer.appendChild(jsonData);
    apiButtonsDiv.appendChild(buttonContainer);
});

// Objeto para rastrear el estado de visibilidad del JSON
const jsonVisibility = {};

function toggleDatos(apiUrl, jsonDataElement, buttonElement) {
    if (jsonVisibility[apiUrl]) {
        // Si el JSON está visible, ocúltalo
        jsonDataElement.classList.remove('visible');
        jsonVisibility[apiUrl] = false;
        buttonElement.textContent = `Mostrar ${jsonDataElement.getAttribute('data-endpoint')}`;
    } else {
        // Si el JSON está oculto, muéstralo
        fetch(apiUrl)
            .then(response => {
                if (response.status === 200) {
                    return response.json();
                } else {
                    throw new Error('Error al obtener los datos de la API');
                }
            })
            .then(data => {
                jsonDataElement.textContent = JSON.stringify(data, null, 4);
                jsonDataElement.classList.add('visible');
                jsonVisibility[apiUrl] = true;
                buttonElement.textContent = `Ocultar ${jsonDataElement.getAttribute('data-endpoint')}`;
            })
            .catch(error => {
                console.error(error);
                jsonDataElement.textContent = 'Error al obtener los datos de la API';
                jsonDataElement.classList.add('visible');
            });
    }
}

    // const buttonsDiv = document.getElementById('buttons');
    // const datosDiv = document.getElementById('datos');
    // let datosVisible = false;
    
    // // Lista de URLs y sus nombres
    // const apiEndpoints = [
        
        // ];
        
        // // Crea botones para cada recurso
        // apiEndpoints.forEach(endpoint => {
            //     const button = document.createElement('button');
            //     button.className = 'api-button';
            //     button.textContent = `Mostrar ${endpoint.name}`;
            //     button.addEventListener('click', () => obtenerDatos(endpoint.url));
            //     buttonsDiv.appendChild(button);
            // });
            
            // function obtenerDatos(apiUrl) {
                //     // Realiza una solicitud GET a la API
                //     fetch(apiUrl)
                //         .then(response => {
                    //             // Verifica si la solicitud fue exitosa (código de estado 200)
                    //             if (response.status === 200) {
                        //                 return response.json(); // Parsea la respuesta JSON
                        //             } else {
                            //                 throw new Error('Error al obtener los datos de la API');
                            //             }
                            //         })
                            //         .then(data => {
                                //             // Formatear y mostrar los datos en el div
                                //             datosDiv.textContent = JSON.stringify(data, null, 4); // Espaciado adicional
                                //             datosDiv.style.display = 'block'; // Mostrar los datos
                                //         })
                                //         .catch(error => {
                                    //             console.error(error);
                                    //             datosDiv.textContent = 'Error al obtener los datos de la API';
                                    //         });
                                    // }