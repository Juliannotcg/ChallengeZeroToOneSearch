import React, {useEffect, useCallback} from 'react';
import {TextField, Button, Dialog, DialogActions, DialogContent, Icon, IconButton, Typography, Toolbar, AppBar, Avatar} from '@material-ui/core';
import {useForm} from '@fuse/hooks';
import FuseUtils from '@fuse/FuseUtils';
import * as Actions from './store/actions/category.actions';
import {useDispatch, useSelector} from 'react-redux';

const defaultFormState = {
    id       : '',
    name     : ''
};

function CategoryDialog(props)
{
    const dispatch = useDispatch();
    const categoryDialog = useSelector(({categoryApp}) => categoryApp.category.categoryDialog);

    const {form, handleChange, setForm} = useForm(defaultFormState);

    const initDialog = useCallback(
        () => {
            
            if ( categoryDialog.type === 'edit' && categoryDialog.data )
            {
                setForm({...categoryDialog.data});
            }

            if ( categoryDialog.type === 'new' )
            {
                setForm({
                    ...defaultFormState,
                    ...categoryDialog.data,
                    id: FuseUtils.generateGUID()
                });
            }
        },
        [categoryDialog.data, categoryDialog.type, setForm],
    );

    useEffect(() => {
        if ( categoryDialog.props.open )
        {
            initDialog();
        }

    }, [categoryDialog.props.open, initDialog]);

    function closeComposeDialog()
    {
        categoryDialog.type === 'edit' ? dispatch(Actions.closeEditCategoryDialog()) : dispatch(Actions.closeNewCategoryDialog());
    }

    function handleSubmit(event)
    {
        console.log("CATEGORY", form)
        const obj = {
            "name": form.name
        }

        event.preventDefault();
        dispatch(Actions.addCategory(obj));
        closeComposeDialog();
    }

    function handleRemove()
    {
       // dispatch(Actions.removeCategory(form.id));
        closeComposeDialog();
    }

    return (
        <Dialog
            classes={{
                paper: "m-24"
            }}
            {...categoryDialog.props}
            onClose={closeComposeDialog}
            fullWidth
            maxWidth="xs"
        >

            <AppBar position="static" elevation={1}>
                <Toolbar className="flex w-full">
                    <Typography variant="subtitle1" color="inherit">
                        {categoryDialog.type === 'new' ? 'New Category' : `Update Category: ${form.name}`}
                    </Typography>
                </Toolbar>
      
            </AppBar>
            <form noValidate onSubmit={handleSubmit} className="flex flex-col overflow-hidden">
                <DialogContent classes={{root: "p-24"}}>
                    <div className="flex">
                        <div className="min-w-48 pt-20">
                            <Icon color="action">format_list_numbered</Icon>
                        </div>

                        <TextField
                            className="mb-24"
                            label="Name"
                            autoFocus
                            id="name"
                            name="name"
                            value={form.name}
                            onChange={handleChange}
                            variant="outlined"
                            required
                            fullWidth
                        />
                    </div>
                </DialogContent>

                {categoryDialog.type === 'new' ? (
                    <DialogActions className="justify-between pl-16">
                        <Button
                            variant="contained"
                            color="primary"
                            onClick={handleSubmit}
                            type="submit"
                        >
                            Adicionar
                        </Button>
                    </DialogActions>
                ) : (
                    <DialogActions className="justify-between pl-16">
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            onClick={handleSubmit}
                        >
                            Salvar
                        </Button>
                        <IconButton
                            onClick={handleRemove}
                        >
                            <Icon>delete</Icon>
                        </IconButton>
                    </DialogActions>
                )}
            </form>
        </Dialog>
    );
}

export default CategoryDialog;
