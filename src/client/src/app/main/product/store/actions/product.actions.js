import axios from 'axios';
import {showMessage} from 'app/store/actions/fuse';

export const GET_PRODUCT = 'GET_PRODUCT';
export const GET_PRODUCTS = 'GET PRODUCTS';
export const GET_CATEGORIES_ALL = 'GET_CATEGORIES_ALL';
export const TOGGLE_IN_SELECTED_PRODUCTS = 'TOGGLE IN SELECTED PRODUCTS';
export const OPEN_NEW_PRODUCT_DIALOG = 'OPEN NEW PRODUCT DIALOG';
export const CLOSE_NEW_PRODUCT_DIALOG = 'CLOSE NEW PRODUCT DIALOG';
export const OPEN_EDIT_PRODUCT_DIALOG = 'OPEN EDIT PRODUCT DIALOG';
export const CLOSE_EDIT_PRODUCT_DIALOG = 'CLOSE EDIT PRODUCT DIALOG';
export const ADD_PRODUCT = 'ADD PRODUCT';
export const UPDATE_PRODUCT = 'UPDATE PRODUCT';
export const REMOVE_PRODUCT = 'REMOVE PRODUCT';
export const REMOVE_PRODUCTS = 'REMOVE PRODUCTS';
export const TOGGLE_STARRED_PRODUCT = 'TOGGLE STARRED PRODUCT';
export const TOGGLE_STARRED_PRODUCTS = 'TOGGLE STARRED PRODUCTS';
export const SET_PRODUCTS_STARRED = 'SET PRODUCTS STARRED ';

const urlApi = "https://localhost:44388"
export function getProducts()
{
    return (dispatch) =>
    axios.get(urlApi + '/api/v1/Products')
    .then((response) => 
            dispatch({
                type   : GET_PRODUCTS,
                payload: response.data
            }))
    .then(() => dispatch(getCategories()));

}
export function getCategories()
{
    return (dispatch) =>
    axios.get(urlApi + '/api/v1/Categories')
    .then((response) => 
            dispatch({
                type   : GET_CATEGORIES_ALL,
                payload: response.data
            }));
}

export function toggleInSelectedProducts(contactId)
{
    return {
        type: TOGGLE_IN_SELECTED_PRODUCTS,
        contactId
    }
}

export function openNewProductDialog()
{
    return {
        type: OPEN_NEW_PRODUCT_DIALOG
    }
}

export function closeNewProductDialog()
{
    return {
        type: CLOSE_NEW_PRODUCT_DIALOG
    }
}

export function openEditProductDialog(data)
{
    return {
        type: OPEN_EDIT_PRODUCT_DIALOG,
        data
    }
}

export function closeEditProductDialog()
{
    return {
        type: CLOSE_EDIT_PRODUCT_DIALOG
    }
}

export function addProduct(newProduct)
{
    console.log("OBJETO", newProduct)
    return (dispatch, getState) => {

        const request = axios.post(urlApi + '/api/v1/Product', newProduct);

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: ADD_PRODUCT
                })
            ]).then(() => dispatch(getProducts()))
        );
    };
}

export function updateProduct(contact)
{
    return (dispatch, getState) => {

        const {routeParams} = getState().contactsApp.contacts;

        const request = axios.post('/api/contacts-app/update-contact', {
            contact
        });

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: UPDATE_PRODUCT
                })
            ]).then(() => dispatch(getProducts(routeParams)))
        );
    };
}

export function removeProduct(contactId)
{
    return (dispatch, getState) => {

        const {routeParams} = getState().contactsApp.contacts;

        const request = axios.post('/api/contacts-app/remove-contact', {
            contactId
        });

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: REMOVE_PRODUCT
                })
            ]).then(() => dispatch(getProducts(routeParams)))
        );
    };
}



















