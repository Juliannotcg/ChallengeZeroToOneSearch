import React, { useState, useEffect } from 'react';
import { FusePageCarded } from '@fuse';
import ProductHeader from './ProductHeader';
import ProductDialog from './ProductDialog';
import ProductsList from './ProductsList';
import withReducer from 'app/store/withReducer';
import reducer from './store/reducers';
import * as Actions from './store/actions/product.actions'
import { useDispatch, useSelector } from 'react-redux';


function Product(props) {

    const dispatch = useDispatch();
    const product = useSelector(({ productApp }) => productApp.product);

    useEffect(() => {
        dispatch(Actions.getProducts());
    }, []);

    return (
        <React.Fragment>
            <FusePageCarded
                header={
                    <ProductHeader />
                }
                content={
                    product.products && <ProductsList dados={product.products} />
                }
                innerScroll
            />
            <ProductDialog />
        </React.Fragment>
    );
}
export default withReducer('productApp', reducer)(Product);


