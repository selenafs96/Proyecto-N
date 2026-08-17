import pandas as pd

# Leer el CSV asegurando la codificación correcta
try:
    # Cambia 'ciqual_traducido.csv' si tu archivo se llama de otra forma
    df = pd.read_csv('ciqual_traducido.csv', encoding='utf-8')
    
    # Guardarlo como un archivo de Excel nativo (.xlsx)
    df.to_excel('ciqual_traducido.xlsx', index=False, engine='openpyxl')
    print("✅ ¡Éxito! Se ha creado 'ciqual_traducido.xlsx' con las celdas alineadas correctamente.")
except Exception as e:
    print(f"❌ Ocurrió un error al convertir: {e}")
