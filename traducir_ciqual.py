import pandas as pd
from deep_translator import GoogleTranslator
from tqdm import tqdm
import time

# --- CONFIGURACIÓN ---
# Reemplaza 'ciqual_original.xlsx' por el nombre real de tu archivo descargado
ARCHIVO_ENTRADA = 'ciqual_original.xls'
ARCHIVO_SALIDA = 'ciqual_traducido.csv'

COLUMNAS_A_TRADUCIR = [
    'alim_grp_nom_eng',    # Grupo principal
    'alim_ssgrp_nom_eng',  # Subgrupo
    'alim_nom_eng'         # Nombre del alimento
]

def traducir_lista_unica(lista_textos):
    """Traduce una lista de textos únicos usando un bucle con pausas de seguridad."""
    traductor = GoogleTranslator(source='en', target='es')
    diccionario_traducido = {}
    
    print(f"Traduciendo {len(lista_textos)} términos únicos...")
    # tqdm muestra una barra de progreso animada en la terminal
    for texto in tqdm(lista_textos):
        if pd.isna(texto) or str(texto).strip() == "":
            diccionario_traducido[texto] = ""
            continue
            
        texto_str = str(texto).strip()
        
        # Reintentos automáticos si falla la conexión momentáneamente
        for intento in range(3):
            try:
                traduccion = traductor.translate(texto_str)
                diccionario_traducido[texto] = traduccion
                break
            except Exception:
                if intento == 2:
                    diccionario_traducido[texto] = texto_str  # Si falla, deja el original
                time.sleep(2)
        
        # Pausa de cortesía para no saturar el servidor de traducción
        time.sleep(0.3)
        
    return diccionario_traducido

if __name__ == "__main__":
    print("Cargando el archivo Excel de CIQUAL...")
    try:
        df = pd.read_excel(ARCHIVO_ENTRADA)
    except FileNotFoundError:
        print(f"❌ Error: No se encontró el archivo '{ARCHIVO_ENTRADA}' en esta carpeta.")
        exit()

    # Verificar que las columnas existan en el Excel
    for col in COLUMNAS_A_TRADUCIR:
        if col not in df.columns:
            print(f"❌ Error: La columna '{col}' no existe en el archivo. Revisa las cabeceras.")
            exit()

    print("Analizando textos únicos para optimizar el tiempo de traducción...")
    # Extraemos todos los textos de las 3 columnas eliminando duplicados
    todos_los_textos = pd.concat([df[col] for col in COLUMNAS_A_TRADUCIR]).dropna().unique()
    
    # Ejecutar la traducción masiva controlada
    diccionario_maestro = traducir_lista_unica(todos_los_textos)

    print("\nAplicando las traducciones al archivo de datos...")
    # Creamos las nuevas columnas en español mapeando el diccionario creado
    df['grupo_espanol'] = df['alim_grp_nom_eng'].map(diccionario_maestro)
    df['subgrupo_espanol'] = df['alim_ssgrp_nom_eng'].map(diccionario_maestro)
    df['nombre_espanol'] = df['alim_nom_eng'].map(diccionario_maestro)

    # Reorganizar el archivo: colocamos las columnas en español al principio para mayor comodidad
    columnas_espanol = ['grupo_espanol', 'subgrupo_espanol', 'nombre_espanol']
    otras_columnas = [c for c in df.columns if c not in columnas_espanol]
    df = df[columnas_espanol + otras_columnas]

    print(f"Guardando el resultado final en '{ARCHIVO_SALIDA}'...")
    # Lo guardamos en formato CSV (es más rápido y compatible con cualquier Base de Datos)
    df.to_csv(ARCHIVO_SALIDA, index=False, encoding='utf-8')
    
    print("\n✅ ¡Proceso completado con éxito!")
    print(f"Se ha generado el archivo '{ARCHIVO_SALIDA}' con las columnas traducidas al inicio.")
