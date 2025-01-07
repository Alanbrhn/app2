import { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import ProductForm from '../components/ProductForm';

function ProductEditPage() {
    const { id } = useParams(); 
    const navigate = useNavigate();
    const [product, setProduct] = useState(null);

    useEffect(() => {
        if (id) {
          
            fetch(`/api/product/${id}`, {
                headers: { Authorization: `Bearer ${localStorage.getItem('token')}` },
            })
                .then((response) => response.json())
                .then((data) => setProduct(data))
                .catch(() => alert('Product not found.'));
        } else {
            setProduct({ name: '', price: '', description: '' }); 
        }
    }, [id]);

    const handleSubmit = () => {
       
        navigate('/products');
    };

    if (product === null) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>{id ? 'Edit Product' : 'Add New Product'}</h1>
            <ProductForm productId={id} initialData={product} onSubmit={handleSubmit} />
        </div>
    );
}

export default ProductEditPage;
