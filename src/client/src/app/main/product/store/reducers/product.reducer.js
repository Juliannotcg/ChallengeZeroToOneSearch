import * as Actions from '../actions/product.actions';

const initialState = {
    selectedOrgaoIds: [],
    productDialog     : {
        type : 'new',
        props: {
            open: false
        }
    },
    data : null
};

const productReducer = function (state = initialState, action) {
    
    switch ( action.type )
    {
        case Actions.GET_PRODUCT:
        {
            return {
                ...state,
                data: action.payload
            };
        }
        case Actions.TOGGLE_IN_SELECTED_PRODUCTS:
            {
    
                const productId = action.productId;
    
                let selectedOrgaoIds = [...state.selectedOrgaoIds];
    
                if ( selectedOrgaoIds.find(id => id === productId) !== undefined )
                {
                    selectedOrgaoIds = selectedOrgaoIds.filter(id => id !== productId);
                }
                else
                {
                    selectedOrgaoIds = [...selectedOrgaoIds, productId];
                }
    
                return {
                    ...state,
                    selectedOrgaoIds: selectedOrgaoIds
                };
            }
            case Actions.OPEN_NEW_PRODUCT_DIALOG:
            {
                return {
                    ...state,
                    productDialog: {
                        type : 'new',
                        props: {
                            open: true
                        },
                        data : null
                    }
                };
            }
            case Actions.CLOSE_NEW_PRODUCT_DIALOG:
            {
                return {
                    ...state,
                    productDialog: {
                        type : 'new',
                        props: {
                            open: false
                        },
                        data : null
                    }
                };
            }
            case Actions.OPEN_EDIT_PRODUCT_DIALOG:
            {
                return {
                    ...state,
                    productDialog: {
                        type : 'edit',
                        props: {
                            open: true
                        },
                        data : action.data
                    }
                };
            }
            case Actions.CLOSE_EDIT_PRODUCT_DIALOG:
            {
                return {
                    ...state,
                    productDialog: {
                        type : 'edit',
                        props: {
                            open: false
                        },
                        data : null
                    }
                };
            }
        default:
        {
            return state;
        }
    }
};

export default productReducer;
