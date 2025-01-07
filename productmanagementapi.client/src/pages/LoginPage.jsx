import LoginForm from '../components/LoginForm';

function LoginPage() {
    const handleLogin = (token) => {
        localStorage.setItem('token', token); 
        window.location.href = '/products';
    };

    return (
        <div>
            <h1>Login</h1>
            <LoginForm onLogin={handleLogin} />
        </div>
    );
}

export default LoginPage;
