const navigationConfig = [
    {
        'id': 'applications',
        'title': 'Exago',
        'type': 'group',
        'icon': 'apps',
        'children': [
            {
                'id': 'product-component',
                'title': 'Products',
                'type': 'item',
                'icon': 'layers',
                'url': '/products'
            },
            {
                'id': 'category-component',
                'title': 'Category',
                'type': 'item',
                'icon': 'format_list_numbered',
                'url': '/category'
            }
        ]
    }
];

export default navigationConfig;
