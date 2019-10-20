import * as Actions from '../actions/category.actions';

const initialState = {
    selectedOrgaoIds: [],
    categoryDialog     : {
        type : 'new',
        props: {
            open: false
        }
    },
    data : null
};

const categoryReducer = function (state = initialState, action) {
    
    switch ( action.type )
    {
        case Actions.GET_CATEGORY:
        {
            return {
                ...state,
                data: action.payload
            };
        }
        case Actions.TOGGLE_IN_SELECTED_CATEGORIES:
            {
    
                const categoryId = action.categoryId;
    
                let selectedOrgaoIds = [...state.selectedOrgaoIds];
    
                if ( selectedOrgaoIds.find(id => id === categoryId) !== undefined )
                {
                    selectedOrgaoIds = selectedOrgaoIds.filter(id => id !== categoryId);
                }
                else
                {
                    selectedOrgaoIds = [...selectedOrgaoIds, categoryId];
                }
    
                return {
                    ...state,
                    selectedOrgaoIds: selectedOrgaoIds
                };
            }
            case Actions.OPEN_NEW_CATEGORY_DIALOG:
            {
                return {
                    ...state,
                    categoryDialog: {
                        type : 'new',
                        props: {
                            open: true
                        },
                        data : null
                    }
                };
            }
            case Actions.CLOSE_NEW_CATEGORY_DIALOG:
            {
                return {
                    ...state,
                    categoryDialog: {
                        type : 'new',
                        props: {
                            open: false
                        },
                        data : null
                    }
                };
            }
            case Actions.OPEN_EDIT_CATEGORY_DIALOG:
            {
                return {
                    ...state,
                    categoryDialog: {
                        type : 'edit',
                        props: {
                            open: true
                        },
                        data : action.data
                    }
                };
            }
            case Actions.CLOSE_EDIT_CATEGORY_DIALOG:
            {
                return {
                    ...state,
                    categoryDialog: {
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

export default categoryReducer;
