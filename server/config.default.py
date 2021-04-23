server = {
    'address': '0.0.0.0',
    'port': 50051,
    'secure': {
        'enabled': False,
        'cert_path': '../',
        'priv_key_path': '../'
    }
}

video = {
    'output_dir': '../storage/video/'
}

hooks = [
    {
        'class_path': 'hooks.database_hook.DatabaseHook',
        'config': {
            'storage': '../storage/redhvid.sqlite'
        }
    }
]
