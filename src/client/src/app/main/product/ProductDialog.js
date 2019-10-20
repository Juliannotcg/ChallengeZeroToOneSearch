import React, { useEffect, useCallback, useState } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    IconButton,
    Toolbar,
    AppBar,
    Button,
    Card,
    CardContent,
    OutlinedInput,
    Icon,
    TextField,
    Typography,
    CardActions,
    Divider,
    Select,
    InputLabel,
    FormControl,
    MenuItem,
    LinearProgress
} from '@material-ui/core';
import { useForm } from '@fuse/hooks';
import FuseUtils from '@fuse/FuseUtils';
import * as Actions from './store/actions/product.actions';
import { useDispatch, useSelector } from 'react-redux';

const defaultFormState = {
    id: '',
    name: '',
    category: ''
};

function ProductDialog(props) {
    const dispatch = useDispatch();
    const categories = useSelector(({ productApp }) => productApp.product.categories);
    const productDialog = useSelector(({ productApp }) => productApp.product.productDialog);
    const [selectedCategory, setSelectedCategory] = useState('all');

    const { form, handleChange, setForm } = useForm(defaultFormState);

    function handleSelectedCategory(event) {
        setSelectedCategory(event.target.value);
    }

    const initDialog = useCallback(
        () => {

            if (productDialog.type === 'edit' && productDialog.data) {
                setForm({ ...productDialog.data });
            }

            if (productDialog.type === 'new') {
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
        if (productDialog.props.open) {
            initDialog();
        }

    }, [productDialog.props.open, initDialog]);

    function closeComposeDialog() {
        productDialog.type === 'edit' ? dispatch(Actions.closeEditProductDialog()) : dispatch(Actions.closeNewProductDialog());
    }

    function handleSubmit(event) {

        const obj = {
            "name": form.name,
            "price": 20,
            "categoryId": selectedCategory
        }

        event.preventDefault();
        dispatch(Actions.addProduct(obj));
        closeComposeDialog();
    }

    function handleRemove() {
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
                <DialogContent classes={{ root: "p-24" }}>
                    <div className="flex">
                        <div className="min-w-48 pt-20">
                            <Icon color="action">layers</Icon>
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
                            <Icon color="action">format_list_numbered</Icon>
                        </div>
                        <FormControl className="flex w-full sm:w-320 mx-20" variant="outlined">
                            <InputLabel htmlFor="category-label-placeholder">
                                Category
                        </InputLabel>
                            <Select
                                value={selectedCategory}
                                onChange={handleSelectedCategory}
                                input={
                                    <OutlinedInput
                                        labelWidth={("category".length * 9)}
                                        name="category"
                                        id="category"
                                    />
                                }
                                fullWidth
                            >
                                {categories && categories.map(category => (
                                    <MenuItem value={category.id} key={category.id}>{category.name}</MenuItem>
                                ))}
                            </Select>
                        </FormControl>
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
