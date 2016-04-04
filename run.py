#!/usr/bin/env python
from skdl import api as app
import sys
import signal
import cherrypy
from logging import getLogger


logger = getLogger(__name__)
server = None


# Start server
def start_server(port, debug=False):
    global server
    # Ready to serve
    logger.info("Server is starting on port {}".format(port))

    # Set exit handler
    set_exit_handler(on_exit)

    # Enable debug for flask
    app.debug = debug
    app.use_debugger = debug
    app.use_reloader = debug

    cherrypy.config.update({
        'engine.autoreload.on': debug,
        'log.screen': True,
        'server.socket_port': port,
        'server.socket_host': '0.0.0.0'
    })
    # Mount the WSGI callable object (app) on the root directory
    cherrypy.tree.graft(app, '/')
    cherrypy.engine.start()
    cherrypy.engine.block()


# Stop server
def stop_server():
    cherrypy.engine.exit()


# Define Exit handler
def set_exit_handler(func):
    signal.signal(signal.SIGTERM, func)


def on_exit(sig, func=None):
    logger.info("Exit handler triggered")
    stop_server()
    sys.exit(0)

