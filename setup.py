#!/usr/bin/env python
from setuptools import setup, find_packages
import py2exe  # noqa

setup(
    name='SKDL',
    version='2.0.0a0',

    packages=find_packages(),

    install_requires=[
        'python-dateutil>=2.2,<3.0.0',
        'argh>=0.26.1',
        'CherryPy==3.8.0',
        'Flask==0.10.1',
        'requests==2.7.0',
        'paste'
    ],

    entry_points={
        'console_scripts': [
            'skdl = skdl.cli:main',
        ],
    },

    console=[
        {
            'script': 'skdl/cli.py',
            'dest_base': 'SKDL'
        }
    ],

    options={
        'py2exe': {
            'packages': ['skdl'],
            'bundle_files': 1, 'compressed': True
        },
    },

    zipfile=None
)
