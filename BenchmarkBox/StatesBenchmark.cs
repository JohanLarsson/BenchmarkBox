namespace BenchmarkBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;

    public class StatesBenchmark
    {
        private static readonly Dictionary<State, string> MapWithComparer = Enum.GetValues(typeof(State))
            .Cast<State>()
            .ToDictionary(
                x => x,
                x => GetState(x),
                new StateComparer());

        private static readonly Dictionary<State, string> Map = Enum.GetValues(typeof(State))
            .Cast<State>()
            .ToDictionary(
                x => x,
                x => GetState(x));

        [Benchmark(Baseline = true)]
        public string SwitchAL()
        {
            return GetState(State.AL);
        }

        [Benchmark]
        public string SwitchWY()
        {
            return GetState(State.WY);
        }

        [Benchmark]
        public string DictionaryWithComparerAL()
        {
            return MapWithComparer[State.AL];
        }

        [Benchmark]
        public string DictionaryWithComparerWY()
        {
            return MapWithComparer[State.WY];
        }


        [Benchmark]
        public string DictionaryBoxingAL()
        {
            return Map[State.AL];
        }

        [Benchmark]
        public string DictionaryBoxingWY()
        {
            return Map[State.WY];
        }

        public enum State
        {
            AL,
            AK,
            AS,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            DC,
            FM,
            FL,
            GA,
            GU,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MH,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            MP,
            OH,
            OK,
            OR,
            PW,
            PA,
            PR,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VI,
            VA,
            WA,
            WV,
            WI,
            WY
        }

        public static string GetState(State state)
        {
            switch (state)
            {
                case State.AL:
                    return "ALABAMA";

                case State.AK:
                    return "ALASKA";

                case State.AS:
                    return "AMERICAN SAMOA";

                case State.AZ:
                    return "ARIZONA";

                case State.AR:
                    return "ARKANSAS";

                case State.CA:
                    return "CALIFORNIA";

                case State.CO:
                    return "COLORADO";

                case State.CT:
                    return "CONNECTICUT";

                case State.DE:
                    return "DELAWARE";

                case State.DC:
                    return "DISTRICT OF COLUMBIA";

                case State.FM:
                    return "FEDERATED STATES OF MICRONESIA";

                case State.FL:
                    return "FLORIDA";

                case State.GA:
                    return "GEORGIA";

                case State.GU:
                    return "GUAM";

                case State.HI:
                    return "HAWAII";

                case State.ID:
                    return "IDAHO";

                case State.IL:
                    return "ILLINOIS";

                case State.IN:
                    return "INDIANA";

                case State.IA:
                    return "IOWA";

                case State.KS:
                    return "KANSAS";

                case State.KY:
                    return "KENTUCKY";

                case State.LA:
                    return "LOUISIANA";

                case State.ME:
                    return "MAINE";

                case State.MH:
                    return "MARSHALL ISLANDS";

                case State.MD:
                    return "MARYLAND";

                case State.MA:
                    return "MASSACHUSETTS";

                case State.MI:
                    return "MICHIGAN";

                case State.MN:
                    return "MINNESOTA";

                case State.MS:
                    return "MISSISSIPPI";

                case State.MO:
                    return "MISSOURI";

                case State.MT:
                    return "MONTANA";

                case State.NE:
                    return "NEBRASKA";

                case State.NV:
                    return "NEVADA";

                case State.NH:
                    return "NEW HAMPSHIRE";

                case State.NJ:
                    return "NEW JERSEY";

                case State.NM:
                    return "NEW MEXICO";

                case State.NY:
                    return "NEW YORK";

                case State.NC:
                    return "NORTH CAROLINA";

                case State.ND:
                    return "NORTH DAKOTA";

                case State.MP:
                    return "NORTHERN MARIANA ISLANDS";

                case State.OH:
                    return "OHIO";

                case State.OK:
                    return "OKLAHOMA";

                case State.OR:
                    return "OREGON";

                case State.PW:
                    return "PALAU";

                case State.PA:
                    return "PENNSYLVANIA";

                case State.PR:
                    return "PUERTO RICO";

                case State.RI:
                    return "RHODE ISLAND";

                case State.SC:
                    return "SOUTH CAROLINA";

                case State.SD:
                    return "SOUTH DAKOTA";

                case State.TN:
                    return "TENNESSEE";

                case State.TX:
                    return "TEXAS";

                case State.UT:
                    return "UTAH";

                case State.VT:
                    return "VERMONT";

                case State.VI:
                    return "VIRGIN ISLANDS";

                case State.VA:
                    return "VIRGINIA";

                case State.WA:
                    return "WASHINGTON";

                case State.WV:
                    return "WEST VIRGINIA";

                case State.WI:
                    return "WISCONSIN";

                case State.WY:
                    return "WYOMING";
            }

            throw new Exception("Not Available");
        }

        public class StateComparer : IEqualityComparer<State>
        {
            public bool Equals(State x, State y)
            {
                return x == y;
            }

            public int GetHashCode(State obj)
            {
                // you need to do some thinking here,
                return (int)obj;
            }
        }
    }
}
