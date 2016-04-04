#!/usr/bin/env python
from contextlib import contextmanager
from sarge import run
import shutil
import click
import sys
import os
from subprocess import call
from os.path import abspath, dirname


@click.group()
def cli():
    pass


@cli.command(help="Run unit tests")
@click.option('--watch', '-w', default=False, is_flag=True,
              help="Watch for file changes")
def test(watch):
    if watch:
        return run('nosetests --with-watch')
    return run('nosetests')


@cli.command(help="Run unit tests and get a coverage report")
def coverage():
    run('coverage run setup.py -q nosetests')
    run('coverage report -m')
    run('coverage html')
    browse_to('.htmlcov/index.html')


@cli.command(help="Check for PEP8 violations")
def flake():
    return call(['flake8', abspath(dirname(__file__))])


def rm(path):
    if os.path.isfile(path):
        os.remove(path)


def rm_rf(path):
    if os.path.isdir(path):
        shutil.rmtree(path)


@contextmanager
def cd(path):
    cwd = os.getcwd()
    try:
        os.chdir(path)
        yield
    finally:
        os.chdir(cwd)


def browse_to(filepath):
    filepath = os.path.abspath(filepath)

    if sys.platform.startswith('darwin'):
        run('open', filepath)
    elif os.name == 'nt':
        os.startfile(filepath)
    elif os.name == 'posix':
        run('xgd-open', filepath)


ROOT = os.path.abspath(os.path.dirname(__file__))

if __name__ == '__main__':
    with cd(ROOT):
        sys.exit(cli())
