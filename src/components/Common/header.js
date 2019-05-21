import React from 'react';
import { Link } from "react-router-dom"


const Header = () => {

    return (
        <header>
            <h2>Vehicle Web App</h2><br/>
                <Link to="/">
                    <button>Home</button>
                </Link>

                <Link to="/vehicleMakes">
                    <button>VehicleMakes</button>
                </Link>
                    
                <Link to="/vehicleModels">
                    <button>Vehicle Models</button>
                </Link>
                <hr/>
        </header>
    );
};

export default Header;

