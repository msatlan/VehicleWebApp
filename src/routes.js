import React from 'react';
import { Switch, Route } from "react-router-dom";

import Layout from "./hoc/layout";
import Home from "./components/Home/home";
import VehicleMakes from "./components/VehicleMakes/vehicleMakes";
import VehicleModels from "./components/VehicleModels/vehicleModels";


const Routes = () => {
    return (
        <Layout>
            <Switch>
                <Route path="/" exact component={Home}/>
                <Route path="/vehicleMakes" exact component={VehicleMakes}/>
                <Route path="/vehicleModels" exact component={VehicleModels}/>
            </Switch>
        </Layout>
    );
};

export default Routes;