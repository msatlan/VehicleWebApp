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
    
                    {this.props.content.map((object) => (
                    <tr key={object.id}>
                        <td>{object.name}</td>
                        <td>{object.id}</td>
                        <td>{object.abbreviation}</td>
                        <td>{object.models.join(", ")}</td>
                        <td>
                            <Link to={{
                                pathname: `/edit/${object.name}`,
                                vehicle: object,
                                readOnly: false   
                            }}>
                                <button>Edit</button>
                            </Link>

                            <Link to={{
                                pathname: `/details/${object.name}`,
                                vehicle: object,
                                readOnly: true
                            }}> 
                                <button>Details</button>
                            </Link>
                            
                            <button onClick={() => this.delete(object.id)}>Delete</button>
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