const api = {
    login: (data) => fetch('/api/Auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    }),
    register: (data) => fetch('/api/Auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    }),
    getProducts: () => fetch('/api/Product/all', { method: 'GET' }),
    addProduct: (data) => fetch('/api/Product', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    }),
    updateProduct: (id, data) => fetch(`/api/Product/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    }),
    deleteProduct: (id) => fetch(`/api/Product/${id}`, {
        method: 'DELETE'
    }),
};

export default api;
