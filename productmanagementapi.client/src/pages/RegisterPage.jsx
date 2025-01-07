import RegisterForm from '../components/RegisterForm';

function RegisterPage() {
    const handleRegister = () => {
        window.location.href = '/login'; 
    };

    return (
        <div>
            <h1>Register</h1>
            <RegisterForm onRegister={handleRegister} />
        </div>
    );
}

export default RegisterPage;
