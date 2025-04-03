import React from 'react';
import { Link } from 'react-router-dom';

const App = () => {
    return (
        <div>
            <h1>Task Manager</h1>
            <nav>
                <Link to="/login">Login</Link> | <Link to="/signup">Signup</Link>
            </nav>
        </div>
    );
};

export default App;