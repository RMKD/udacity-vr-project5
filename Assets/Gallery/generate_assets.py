import subprocess
import json

def run():
    with open("info.json") as f :
        info = json.load(f)
        for record in info:
            clean_name = record['project'].lower().replace(' ','_').replace('.','_')
            subprocess.call(['espeak', record['description'], '-w', clean_name + '.wav'])
            subprocess.call(['espeak', 'This project was built by '+ ', '.join(record['credits']), '-w', clean_name + '_credits.wav'])

if __name__ == "__main__":
    run()
