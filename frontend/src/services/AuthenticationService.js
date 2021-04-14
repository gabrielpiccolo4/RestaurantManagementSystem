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

async function signup(name, email, password) {
    let response;

    try {
        await api.post('/signup', {
            Name: name,
            Email: email,
            Password: password
        });
    } catch (error) {
        throw error;
    }

    return response;
}

export { login, logout, signup };
