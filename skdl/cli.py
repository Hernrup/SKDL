import argh
from run import start_server


def run(port=5000, debug=True):
    start_server(port)


def run_parser():
    parser = argh.ArghParser()
    parser.add_commands([run])
    parser.set_default_command(run)
    parser.dispatch()

if __name__ == '__main__':
    run_parser()