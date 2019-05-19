import React, { Component } from "react";
import { Link } from "react-router-dom";

class Table extends Component {

    delete = (id) => {
        this.props.delete(id);
    } 

    render() {
        return(
            <table border="1" cellPadding="10" cellSpacing="1">
    
                <thead>
                    <tr>
                        <td colSpan="5">Table header</td>
                    </tr>
                </thead>
    
                <tfoot>
                    <tr>
                        <td colSpan="5">Table footer</td>
                    </tr>
                </tfoot>
    
                <tbody> 
                    <tr>
                        <th>Name</th>
                        <th>Id</th>
                        <th>Abbreviation</th>
                        <th>Models</th>
                        <th></th>
                    </tr>
    
                    {this.props.vehicleMakes.map((vehicle) => (
                    <tr key={vehicle.id}>
                        <td>{vehicle.name}</td>
                        <td>{vehicle.id}</td>
                        <td>{vehicle.abbreviation}</td>
                        <td>{vehicle.models.join(", ")}</td>
                        <td>
                            <Link to={`/edit/${vehicle.name}`}><button>Edit</button></Link>
                            <Link to={`/details/${vehicle.name}`}><button>Details</button></Link>
                            <button onClick={() => this.delete(vehicle.id)}>Delete</button>
                        </td>
                    </tr>
                    ))
                    }
                </tbody>
            </table>
        )
    }   
}

export default Table;