const baseUrl = "http://localhost:5000/api/sicer/";

const config = {
    headers: new Headers({
        "Content-Type": "application/json"
    })
};

const getDataAll = async () => {
    try {
        const response = await fetch(baseUrl, config);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error in getDataAll:", error);
        throw error;
    }
};

const postData = async (data) => {
    try {
        config.method = "POST";
        config.body = JSON.stringify(data);

        const response = await fetch(baseUrl, config);
        const result = await response.json();
        console.log(result);
    } catch (error) {
        console.error("Error in postData:", error);
        throw error;
    }
};

const putData = async (data, id) => {
    try {
        config.method = "PUT";
        config.body = JSON.stringify(data);

        const response = await fetch(baseUrl + id, config);
        const result = await response.json();
        console.log(result);
    } catch (error) {
        console.error("Error in putData:", error);
        throw error;
    }
};

const deleteData = async (id) => {
    try {
        config.method = "DELETE";

        const response = await fetch(baseUrl + id, config);
        const result = await response.json();
        console.log(result);
    } catch (error) {
        console.error("Error in deleteData:", error);
        throw error;
    }
};

const searchData = async (data) => {
    try {
        const queryString = Object.values(data).join("");
        const response = await fetch(baseUrl + `?q=${queryString}`, config);
        const result = await response.json();
        console.log(result);
    } catch (error) {
        console.error("Error in searchData:", error);
        throw error;
    }
};

const searchDataById = async (id) => {
    try {
        const response = await fetch(baseUrl + id, config);
        const result = await response.json();
        console.log(result);
        return result;
    } catch (error) {
        console.error("Error in searchDataById:", error);
        throw error;
    }
};

// Ejemplo de cómo utilizar estas funciones en el HTML
async function getData() {
    try {
        const data = await getDataAll();
        document.getElementById("result").textContent = JSON.stringify(data, null, 2);
    } catch (error) {
        console.error("Error in getData:", error);
    }
}

// Repite un bloque similar para las otras funciones de API (postData, putData, deleteData, searchData, searchDataById)
