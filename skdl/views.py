from . import api
from flask import render_template, send_from_directory
import json
from . import JsonResponse
from . import models
import logging

logger = logging.getLogger(__name__)


@api.route('/', methods=['GET'])
def main_view():
    return render_template('layout.html')

