﻿using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class LabelFactory
    {
        #region Properties

        public List<ZPLLabel> BoxLabels { get; set; }

        public List<FBABox> ShipmentBoxes { get; set; }

        public AmzWarehouseModel AmzWarehouse { get; set; }

        public CompanyAddressModel ShipFromAddress { get; set; }

        #endregion


        #region Constructors
        public LabelFactory()
        {
            BoxLabels = new List<ZPLLabel>();
            ShipmentBoxes = new List<FBABox>();
            AmzWarehouse = new AmzWarehouseModel();
            ShipFromAddress = new CompanyAddressModel();
        }

        public LabelFactory(List<FBABox> boxes, AmzWarehouseModel shipTo, CompanyAddressModel shipFrom)
        {
            ShipmentBoxes = boxes;
            BoxLabels = new List<ZPLLabel>();
            AmzWarehouse = shipTo;
            ShipFromAddress = shipFrom;
            CreateLabels();

        }
        #endregion


        #region Methods

        public void CreateLabels()
        {
            int boxCount = ShipmentBoxes.Count;

            //iterate through each box in the shipmentBoxes objects
            foreach(FBABox box in ShipmentBoxes)
            {
                //create a new label for each box.
                ZPLLabel label = new ZPLLabel(AmzWarehouse, ShipFromAddress, box);

                //create the label, pass in box count so the label prints out "Box # of BoxCount"
                label.CreateLabel(boxCount);

                //add label to list of labels
                BoxLabels.Add(label);

            }
        }

        #endregion
    }
}
