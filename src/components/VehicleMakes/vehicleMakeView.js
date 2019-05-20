import React, { Component } from 'react';

class VehicleMakeView extends Component {



    render() {

        return (
            <div>
                <header>
                    <h3>Name: {this.props.location.vehicle.name}</h3>
                </header>
                <div>
                    Id: <input value={this.props.location.vehicle.id}
                               style={{
                                   width:"400px",
                                   position: "absolute",
                                   left: "200px"
                               }}  
                               readOnly/><br/>
                    Abbreviation: <input value={this.props.location.vehicle.abbreviation} 
                                         style={{
                                            width:"400px",
                                            position: "absolute",
                                            left: "200px"
                                         }}  
                                         readOnly/><br/>
                    Models: <input value={this.props.location.vehicle.models.join(", ")}
                                   style={{
                                        width:"400px",
                                        position: "absolute",
                                        left: "200px"
                                    }}  
                                    readOnly/><br/>
                </div>
            </div>
        );
    }
};

export default VehicleMakeView;