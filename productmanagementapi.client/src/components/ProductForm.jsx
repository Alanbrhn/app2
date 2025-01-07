import { useState, useEffect } from 'react';

function ProductForm({ productId, initialData, onSubmit }) {
    const [name, setName] = useState('');
    const [price, setPrice] = useState('');
    const [description, setDescription] = useState('');

    useEffect(() => {
        if (initialData) {
            setName(initialData.name || '');
            setPrice(initialData.price || '');
            setDescription(initialData.description || '');
        }
    }, [initialData]);

    const handleFormSubmit = (e) => {
        e.preventDefault();
        const productData = { name, price, description };

        const requestMethod = productId ? 'PUT' : 'POST';
        const url = `/api/product/${productId || ''}`;

        fetch(url, {
            method: requestMethod,
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${localStorage.getItem('token')}`,
            },
            body: JSON.stringify(productData),
        })
            .then((response) => {
                if (response.ok) {
                    onSubmit();  
                } else {
                    alert('Failed to save product');
                }
            })
            .catch(() => alert('Error saving product'));
    };

    return (
        <form onSubmit={handleFormSubmit}>
            <div>
                <label>Name</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
            </div>
            <div>
                <label>Price</label>
                <input
                    type="number"
                    value={price}
                    onChange={(e) => setPrice(e.target.value)}
                />
            </div>
            <div>
                <label>Description</label>
                <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
            </div>
            <button type="submit">{productId ? 'Update' : 'Add'} Product</button>
        </form>
    );
}

export default ProductForm;
