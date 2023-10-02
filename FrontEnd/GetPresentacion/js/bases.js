const apiButtonsDiv = document.getElementById('api-buttons');

// Lista de URLs y sus nombres
const apiEndpoints = [
    { url: 'http://localhost:5000/api/sicer/CargoEmpleado/', name: 'CargoEmpleado' },
    { url: 'http://localhost:5000/api/sicer/CategoriaMedicamento/', name: 'CategoriaMedicamento' },
    { url: 'http://localhost:5000/api/sicer/EstadoCita/', name: 'EstadoCita' },
    { url: 'http://localhost:5000/api/sicer/Farmacia/', name: 'Farmacia' },
    { url: 'http://localhost:5000/api/sicer/Genero/', name: 'Genero' },
    { url: 'http://localhost:5000/api/sicer/MetodoDePago/', name: 'MetodoDePago' },
    { url: 'http://localhost:5000/api/sicer/Pais/', name: 'Pais' },
    { url: 'http://localhost:5000/api/sicer/Presentacion/', name: 'Presentacion' },
    { url: 'http://localhost:5000/api/sicer/Proveedor/', name: 'Proveedor' },
    { url: 'http://localhost:5000/api/sicer/TipoDireccion/', name: 'TipoDireccion' },
    { url: 'http://localhost:5000/api/sicer/TipoMedicamento/', name: 'TipoMedicamento' },
    { url: 'http://localhost:5000/api/sicer/TipoVia/', name: 'TipoVia' },
    { url: 'http://localhost:5000/api/sicer/Empleado/', name: 'Empleado' },
    { url: 'http://localhost:5000/api/sicer/Departamento/', name: 'Departamento' },
    { url: 'http://localhost:5000/api/sicer/Ciudad/', name: 'Ciudad' },
    { url: 'http://localhost:5000/api/sicer/Compra/', name: 'Compra' },
    { url: 'http://localhost:5000/api/sicer/Medicamento/', name: 'Medicamento' },
    { url: 'http://localhost:5000/api/sicer/Paciente/', name: 'Paciente' },
    { url: 'http://localhost:5000/api/sicer/Cita/', name: 'Cita' },
    { url: 'http://localhost:5000/api/sicer/Direccion/', name: 'Direccion' },
    { url: 'http://localhost:5000/api/sicer/FormulaMedica/', name: 'FormulaMedica' },
    { url: 'http://localhost:5000/api/sicer/FormulaMedicamentos/', name: 'FormulaMedicamentos' },
    { url: 'http://localhost:5000/api/sicer/Venta/', name: 'Venta' },
    { url: 'http://localhost:5000/api/sicer/Inventario/', name: 'Inventario' },
    { url: 'http://localhost:5000/api/sicer/MedicamentosComprados/', name: 'MedicamentosComprados' },
    { url: 'http://localhost:5000/api/sicer/MedicamentosVendidos/', name: 'MedicamentosVendidos' },
    { url: 'http://localhost:5000/api/sicer/HistorialMedico/', name: 'HistorialMedico' },
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


