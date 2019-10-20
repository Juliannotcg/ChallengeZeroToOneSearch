import axios from 'axios';
import {showMessage} from 'app/store/actions/fuse';

export const GET_CATEGORY = 'GET_CATEGORY';
export const GET_CATEGORIES = 'GET CATEGORIES';
export const TOGGLE_IN_SELECTED_CATEGORIES = 'TOGGLE IN SELECTED CATEGORIES';
export const OPEN_NEW_CATEGORY_DIALOG = 'OPEN NEW CATEGORY DIALOG';
export const CLOSE_NEW_CATEGORY_DIALOG = 'CLOSE NEW CATEGORY DIALOG';
export const OPEN_EDIT_CATEGORY_DIALOG = 'OPEN EDIT CATEGORY DIALOG';
export const CLOSE_EDIT_CATEGORY_DIALOG = 'CLOSE EDIT CATEGORY DIALOG';
export const ADD_CATEGORY = 'ADD CATEGORY';
export const UPDATE_CATEGORY = 'UPDATE CATEGORY';
export const REMOVE_CATEGORY = 'REMOVE CATEGORY';
export const REMOVE_CATEGORIES = 'REMOVE CATEGORIES';
export const TOGGLE_STARRED_CATEGORY = 'TOGGLE STARRED CATEGORY';
export const TOGGLE_STARRED_CATEGORIES = 'TOGGLE STARRED CATEGORIES';
export const SET_CATEGORIES_STARRED = 'SET CATEGORIES STARRED ';

const urlApi = "https://localhost:44388"
export function getCategories()
{
    return (dispatch) =>
    axios.get(urlApi + '/api/v1/Categories')
    .then((response) => 
            dispatch({
                type   : GET_CATEGORY,
                payload: response.data
            })
        );
}

export function toggleInSelectedCategories(contactId)
{
    return {
        type: TOGGLE_IN_SELECTED_CATEGORIES,
        contactId
    }
}

export function openNewCategoryDialog()
{
    return {
        type: OPEN_NEW_CATEGORY_DIALOG
    }
}

export function closeNewCategoryDialog()
{
    return {
        type: CLOSE_NEW_CATEGORY_DIALOG
    }
}

export function openEditCategoryDialog(data)
{
    return {
        type: OPEN_EDIT_CATEGORY_DIALOG,
        data
    }
}

export function closeEditCategoryDialog()
{
    return {
        type: CLOSE_EDIT_CATEGORY_DIALOG
    }
}

export function addCategory(newCategory)
{
    return (dispatch, getState) => {

        const {routeParams} = getState().contactsApp.contacts;

        const request = axios.post('/api/contacts-app/add-contact', {
            newCategory
        });

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: ADD_CATEGORY
                })
            ]).then(() => dispatch(getCategories(routeParams)))
        );
    };
}

export function updateCategory(contact)
{
    return (dispatch, getState) => {

        const {routeParams} = getState().contactsApp.contacts;

        const request = axios.post('/api/contacts-app/update-contact', {
            contact
        });

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: UPDATE_CATEGORY
                })
            ]).then(() => dispatch(getCategories(routeParams)))
        );
    };
}

export function removeCategory(contactId)
{
    return (dispatch, getState) => {

        const {routeParams} = getState().contactsApp.contacts;

        const request = axios.post('/api/contacts-app/remove-contact', {
            contactId
        });

        return request.then((response) =>
            Promise.all([
                dispatch({
                    type: REMOVE_CATEGORY
                })
            ]).then(() => dispatch(getCategories(routeParams)))
        );
    };
}



















