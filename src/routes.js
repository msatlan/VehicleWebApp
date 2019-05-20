import React from 'react';
import { Switch, Route } from "react-router-dom";

import Layout from "./hoc/layout";
import Home from "./components/Home/home";
import VehicleMakes from "./components/VehicleMakes/vehicleMakes";
import VehicleMakeView from "./components/VehicleMakes/vehicleMakeView";
import VehicleModels from "./components/VehicleModels/vehicleModels";

const Routes = () => {
    return (
        <Layout>
            <Switch>
                <Route path="/" exact component={Home}/>
                <Route path="/details" component={VehicleMakeView}/>
                <Route path="/vehicleMakes" exact component={VehicleMakes}/>
                <Route path="/vehicleModels" exact component={VehicleModels}/>
            </Switch>
        </Layout>
    );
};
//<Route path="/details" render={(props) => <VehicleMakeView {...props} vehicleMake={props.vehicleMake}/>}/>
export default Routes;