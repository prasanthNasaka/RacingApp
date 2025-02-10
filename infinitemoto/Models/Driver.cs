                                    using System;
                                    using System.Collections.Generic;
                                    using infinitemoto.LookUps;

                                    namespace infinitemoto.Models;

                                    public partial class Driver
                                    {
                                        public int DriverId { get; set; }

                                        public string Drivername { get; set; } = null!;

                                        public string Phone { get; set; } = null!;

                                        public string Email { get; set; } = null!;

                                        public string FmsciNumb { get; set; } = null!;

                                        public DateOnly FmsciValidTill { get; set; }

                                        public string DlNumb { get; set; } = null!;

                                        public DateOnly DlValidTill { get; set; }

                                        public DateOnly Dob { get; set; }

                                        public string Bloodgroup { get; set; }

                                        public int? Teammemberof { get; set; }

                                        public string? DriverPhoto { get; set; }

                                        public string? DlPhoto { get; set; }

                                        public string? FmsciLicPhoto { get; set; }

                                        public bool Status { get; set; }

                                        public virtual Team? TeammemberofNavigation { get; set; }

                                        // public static implicit operator Driver(Driver v)
                                        // {
                                        //     throw new NotImplementedException();
                                        // }
                                    }
