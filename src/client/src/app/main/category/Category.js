import React, { useState, useEffect } from 'react';
import { FusePageCarded } from '@fuse';
import CategoryHeader from './CategoryHeader';
import CategoryDialog from './CategoryDialog';
import CategoriesList from './CategoriesList';
import withReducer from 'app/store/withReducer';
import reducer from './store/reducers';
import * as Actions from './store/actions/category.actions'
import { useDispatch, useSelector } from 'react-redux';


function Category(props) {

    const dispatch = useDispatch();
    const category = useSelector(({ categoryApp }) => categoryApp.category);

    useEffect(() => {
        dispatch(Actions.getCategories());
    }, []);

    return (
        <React.Fragment>
            <FusePageCarded
                header={
                    <CategoryHeader />
                }
                content={
                    category.data && <CategoriesList dados={category.data} />
                }
                innerScroll
            />
            <CategoryDialog />
        </React.Fragment>
    );
}
export default withReducer('categoryApp', reducer)(Category);


