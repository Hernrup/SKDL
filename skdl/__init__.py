from flask import Flask, Response
import logging

logging.basicConfig(level=logging.DEBUG,
                    format='%(asctime)s - %(levelname)s - %(message)s')

api = Flask(__name__, static_url_path='/static')


class NotModified(Exception):
    pass


class BadRequestError(Exception):
    pass


class NotFoundError(Exception):
    pass


class JsonResponse(Response):
    default_mimetype = 'application/json'


from . import views, error_handlers, models
