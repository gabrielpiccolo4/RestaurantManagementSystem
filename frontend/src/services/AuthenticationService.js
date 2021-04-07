import api from './Api';

async function login(email, password) {
    let response;

    try {
        const { data } = await api.post('/login', {
            Email: email,
            Password: password
        });

        const token = data.token;
        api.defaults.headers.common.Authorization = `Bearer ${token}`;

        response = data.user;
    } catch (error) {
        throw error;
    }

    return response;
}

function logout() {
    delete api.defaults.headers.common.Authorization;
}

export { login, logout };
