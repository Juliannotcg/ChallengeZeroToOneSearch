import React from 'react';
import { Icon, IconButton } from '@material-ui/core';
import { FuseAnimate } from '@fuse';
import ReactTable from "react-table";
import * as Actions from './store/actions/product.actions'
import { useDispatch } from 'react-redux';


function ProductsList(props) {
    
    const dispatch = useDispatch();

console.log("PROPS:", props)

    return (
        <React.Fragment>
            <FuseAnimate animation="transition.slideUpIn" delay={300}>
                <ReactTable
                    className="-striped -highlight h-full sm:rounded-16 overflow-hidden"
                    getTrProps={(state, rowInfo, column) => {
                        return {
                            className: "cursor-pointer",
                        }
                    }}
                    data={props.dados}
                    columns={[
                        {
                            Header: "Name",
                            accessor: "name",
                            filterable: true,
                            className: "font-bold"
                        },
                        {
                            Header: "Category",
                            accessor: "category.name",
                            filterable: true,
                            className: "font-bold"
                        },
                        {
                            Header: "",
                            width: 128,
                            Cell: row => (
                                <div className="flex items-center">
                                    <IconButton
                                        onClick={(ev) => {
                                            dispatch(Actions.openEditProductDialog(row.original));
                                        }}
                                    >
                                        <Icon>edit</Icon>

                                    </IconButton>
                                    <IconButton

                                    >
                                        <Icon>delete</Icon>
                                    </IconButton>
                                </div>
                            )
                        }
                    ]}
                    defaultPageSize={10}
                    noDataText="No contacts found"
                />
            </FuseAnimate>
    
        </React.Fragment>
    );
}


export default ProductsList;
