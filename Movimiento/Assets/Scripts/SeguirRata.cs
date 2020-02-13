/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/   
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class SeguirRata : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        /// 
        private float directionTime=0;
        private float directionChangeRate=1;
        private Vector3 direccionMedoreamiento=Vector3.zero;

        private void Start()
        {
            direccionMedoreamiento= new Vector3(5, 0, 0);
        }
        public override Direccion GetDireccion()
        {
            Direccion direccion = new Direccion();
            if (objetivo.GetComponent<JugadorAgente>().flauta)
            {
                direccion.lineal = objetivo.transform.position - transform.position;
                direccion.lineal.Normalize();
                direccion.lineal = direccion.lineal * agente.aceleracionMax;
            }
            else
            {
           
                if (Time.realtimeSinceStartup - directionTime >= directionChangeRate)
                {
                  
                 direccionMedoreamiento = -direccionMedoreamiento*10;
                    
                 directionTime = Time.realtimeSinceStartup;
                }
                direccion.lineal = direccionMedoreamiento;


            }
            return direccion;
        }


    }

}
