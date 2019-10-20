import React, {useEffect, useCallback} from 'react';
import {TextField, Button, Dialog, DialogActions, DialogContent, Icon, IconButton, Typography, Toolbar, AppBar, Avatar} from '@material-ui/core';
import {useForm} from '@fuse/hooks';
import FuseUtils from '@fuse/FuseUtils';
import * as Actions from './store/actions/product.actions';
import {useDispatch, useSelector} from 'react-redux';

const defaultFormState = {
    id       : '',
    name     : '',
    category: ''
};

function ProductDialog(props)
{
    const dispatch = useDispatch();
    const productDialog = useSelector(({productApp}) => productApp.product.productDialog);

    const {form, handleChange, setForm} = useForm(defaultFormState);

    const initDialog = useCallback(
        () => {
            
            if ( productDialog.type === 'edit' && productDialog.data )
            {
                setForm({...productDialog.data});
            }

            if ( productDialog.type === 'new' )
            {
                setForm({
                    ...defaultFormState,
                    ...productDialog.data,
                    id: FuseUtils.generateGUID()
                });
            }
        },
        [productDialog.data, productDialog.type, setForm],
    );

    useEffect(() => {
        if ( productDialog.props.open )
        {
            initDialog();
        }

    }, [productDialog.props.open, initDialog]);

    function closeComposeDialog()
    {
        productDialog.type === 'edit' ? dispatch(Actions.closeEditProductDialog()) : dispatch(Actions.closeNewProductDialog());
    }

    function handleSubmit(event)
    {
        event.preventDefault();
        dispatch(Actions.updateProduct(form));
        closeComposeDialog();
    }

    function handleRemove()
    {
       // dispatch(Actions.removeProduct(form.id));
        closeComposeDialog();
    }

    return (
        <Dialog
            classes={{
                paper: "m-24"
            }}
            {...productDialog.props}
            onClose={closeComposeDialog}
            fullWidth
            maxWidth="xs"
        >

            <AppBar position="static" elevation={1}>
                <Toolbar className="flex w-full">
                    <Typography variant="subtitle1" color="inherit">
                        {productDialog.type === 'new' ? 'New Product' : `Update Product: ${form.name}`}
                    </Typography>
                </Toolbar>
      
            </AppBar>
            <form noValidate onSubmit={handleSubmit} className="flex flex-col overflow-hidden">
                <DialogContent classes={{root: "p-24"}}>
                    <div className="flex">
                        <div className="min-w-48 pt-20">
                            <Icon color="action">account_circle</Icon>
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

                    <div className="flex">
                        <div className="min-w-48 pt-20">
                            <Icon color="action">account_circle</Icon>
                        </div>
                        <TextField
                            className="mb-24"
                            label="Category"
                            id="category"
                            name="category"
                            value={form.category.name}
                            onChange={handleChange}
                            variant="outlined"
                            fullWidth
                        />
                    </div>
                </DialogContent>

                {productDialog.type === 'new' ? (
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

export default ProductDialog;
