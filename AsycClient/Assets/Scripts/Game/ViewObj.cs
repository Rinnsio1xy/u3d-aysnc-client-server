using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class ViewObj
    {
        public GameObj gameObj;
        public GameObject gameGo;
        protected ViewMap _viewMap;
        protected Transform gameTrans;
		//public Queue<MoveData> moveDatas;
		public MoveData nextPosData;

        public virtual void Create(CharData charData, ViewMap viewMap)
        {
            _viewMap = viewMap;
            gameObj = new GameObj();
            gameObj.Init(charData, viewMap.LogicMap);
            gameGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameGo.name = charData.name;
            gameTrans = gameGo.transform;
			//moveDatas = new Queue<MoveData> ();

        }

        public int Id
        {
            get
            {
                if(gameObj == null)
                {
                    return -1;
                }
                return gameObj.mCharData.roleId;
            }
        }

        public Vector3 Pos
        {
            get
            {
                if (gameTrans == null)
                {
                    return Vector3.zero;
                }
                return gameTrans.position;
            }
            set
            {
                if (gameTrans != null)
                {
                    gameTrans.position = value;
                }
            }
        }

        public Vector3 EulerAngles
        {
            get
            {
                if (gameTrans == null)
                {
                    return Vector3.zero;
                }
                return gameTrans.localEulerAngles;
            }
            set
            {
                gameTrans.localRotation = Quaternion.Euler(value);
            }
        }

        public virtual void Update()
        {
            if(gameObj == null)
            {
                return;
            }

			if (nextPosData != null) {
				float t = Time.deltaTime / 0.05f;
				//Debug.Log ("lerp time" + t);
				Debug.Log ("gameTrans.position" + gameTrans.position);
				Debug.Log ("======nextPosData.vCurPos" + nextPosData.vCurPos);
				gameTrans.position = Vector3.Lerp (gameTrans.position, nextPosData.vCurPos, t);
				//gameTrans.localEulerAngles = Vector3.Lerp (gameTrans.localEulerAngles, nextPosData.vCurAngle, t);
			}
            gameObj.Update();
        }
    }
}

