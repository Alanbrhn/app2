import Navbar from '../components/Navbar'; 
import Sidebar from '../components/Sidebar'; 

function HomePage() {
    return (
        <div>
            <Navbar />
            <div className="container-fluid">
                <div className="row">
                    <div className="col-md-2">
                        <Sidebar /> 
                    </div>
                    <div className="col-md-10">
                        <h1>Welcome to Home Page</h1>
                       
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HomePage;
