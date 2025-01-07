import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function ProductListPage() {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        fetch('/api/product/all', {
            headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        })
            .then(response => response.json())
            .then(data => setProducts(data));
    }, []);

    return (
        <div>
            <h1>Product List</h1>
            <Link to="/product/new">Add New Product</Link>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Description</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product => (
                        <tr key={product.id}>
                            <td>{product.name}</td>
                            <td>{product.price}</td>
                            <td>{product.description}</td>
                            <td>
                                <Link to={`/product/edit/${product.id}`}>Edit</Link>
                                <button onClick={() => handleDelete(product.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );

    const handleDelete = (id) => {
        fetch(`/api/product/${id}`, {
            method: 'DELETE',
            headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        }).then(() => {
            setProducts(products.filter(product => product.id !== id));
        });
    };
}

export default ProductListPage;
