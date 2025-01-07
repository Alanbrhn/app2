import React from 'react';
import { Link } from 'react-router-dom';
import { Outlet } from 'react-router-dom';

const Layout = () => {
    return (
        <div className="container-fluid">
            <div className="row">
              
                <div className="col-2 bg-dark text-white">
                    <h4>Admin Panel</h4>
                    <ul className="nav flex-column">
                        <li className="nav-item">
                            <Link className="nav-link text-white" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link text-white" to="/products">Product List</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link text-white" to="/product/new">New Product</Link>
                        </li>
                    </ul>
                </div>

              
                <div className="col-10">
                    <header className="bg-primary text-white p-3">
                        <h1>Product Management</h1>
                    </header>
                    <main>
                        <Outlet />  
                    </main>
                </div>
            </div>
        </div>
    );
};

export default Layout;
