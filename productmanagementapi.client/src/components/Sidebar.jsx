function Sidebar() {
    return (
        <div className="sidebar">
            <ul className="list-group">
                <li className="list-group-item">
                    <a href="/products">Product List</a>
                </li>
                <li className="list-group-item">
                    <a href="/product/new">Add Product</a>
                </li>
            </ul>
        </div>
    );
}

export default Sidebar;
